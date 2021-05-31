const fs = require('fs');
const http = require('http');
const https = require('https');
const path = require('path');

async function downloadFile(url, filePath) {    
    const proto = !url.charAt(4).localeCompare('s') ? https : http;

    return new Promise((resolve, reject) => {
        const file = fs.createWriteStream(filePath);
        let fileInfo = null;

        const request = proto.get(url, response => {
            if (response.statusCode !== 200) {
                reject(new Error(`Failed to get '${url}' (${response.statusCode})`));
                return;
            }

            fileInfo = {
                mime: response.headers['content-type'],
                size: parseInt(response.headers['content-length'], 10),
            };

            response.pipe(file);
        });

        // The destination stream is ended by the time it's called
        file.on('finish', () => resolve(fileInfo));

        request.on('error', err => {
            fs.unlink(filePath, () => reject(err));
        });

        file.on('error', err => {
            fs.unlink(filePath, () => reject(err));
        });

        request.end();
    });
}

function modifyFileAfterContext (data, filePath, context) {
  const file = fs.readFileSync(filePath).toString().split('\n')

  let line = -1

  for (let i = 0; i < file.length; i++) {
    const lineString = file[i]

    if (context.trim() === lineString.trim()) {
      line = i
      break
    }
  }

  if (line === -1) {
    throw new Error('Current Blitz version doesn\'t contain the given injection context.')
  }

  if (file[line + 1] !== data) {
    file.splice(line + 1, 0, data)
    const text = file.join('\n')

    fs.writeFileSync(filePath, text)
    console.log(`${filePath} => Writing to line ${line + 2}: ${data}`)
  }
}

function modifyFileAtLine(data, filePath, line, compare=-1) {
    var file = fs.readFileSync(filePath).toString().split("\n");

    if(compare != -1) {
        if(!(data === file[line-1]) && !(compare === file[line-1])) {
            throw new Error(
                `Current Blitz version caused patch comparison check to fail. Look for a new patcher release or create a new issue on Github!
                \n\n
                Finding:\n
                \t'${file[line-1]}'\n
                Instead of:
                \t'${compare}'`);
        }
    }

    file.splice(line-1, 1, data);
    var text = file.join('\n');
    
    fs.writeFileSync(filePath, text);
    console.log(`${filePath} => Writing to line ${line}: ${data}`);
}

function copyFile(src, dest) {
    fs.copyFileSync(src, dest);
}

function deleteFolder(dir_path) {
    if (fs.existsSync(dir_path)) {
        fs.readdirSync(dir_path).forEach(function(entry) {
            var entry_path = path.join(dir_path, entry);
            if (fs.lstatSync(entry_path).isDirectory()) {
                deleteFolder(entry_path);
            } else {
                fs.unlinkSync(entry_path);
            }
        });
        fs.rmdirSync(dir_path);
    }
}

module.exports = {
    downloadFile: downloadFile,
    modifyFileAfterContext: modifyFileAfterContext,
    modifyFileAtLine: modifyFileAtLine,
    copyFile: copyFile,
    deleteFolder: deleteFolder,
};
