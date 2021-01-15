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

function modifyFileAtLine(data, filePath, line) {
    var file = fs.readFileSync(filePath).toString().split("\n");
    file.splice(line-1, 1, data);
    var text = file.join("\n");

    fs.writeFileSync(filePath, text, function (err) {
        if (err) return console.log(err);
    });
    console.log(`${filePath} => Writing to line ${line}: ${data}`);
}

function copyFile(src, dest) {
    fs.copyFileSync(src, dest, (err) => {
        if (err) throw err;
    });
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
    modifyFileAtLine: modifyFileAtLine,
    copyFile: copyFile,
    deleteFolder: deleteFolder,
};