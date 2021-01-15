var filterEngine = 
`try {
    const fs = require('fs');
    const {
        FiltersEngine,
        Request
    } = require('./adblocker.umd.min.js');
    const filters =
        fs.readFileSync(require.resolve('./easylist.txt'), 'utf-8') + '\\n'
    fs.readFileSync(require.resolve('./easyprivacy.txt'), 'utf-8') + '\\n'
    fs.readFileSync(require.resolve('./ublock-ads.txt'), 'utf-8') + '\\n'
    fs.readFileSync(require.resolve('./ublock-privacy.txt'), 'utf-8') + '\\n'
    fs.readFileSync(require.resolve('./peter-lowe-list.txt'), 'utf-8') + '\\ngoogleoptimize.com\\n';
    const engine = FiltersEngine.parse(filters);

    windowInstance.webContents.session.webRequest.onBeforeRequest({
        urls: ['*://*/*']
    }, (details, callback) => {
        const {
            match
        } = engine.match(Request.fromRawDetails({
            url: details.url
        }));
        if (match == true) {
            log.info('BLOCKED:', details.url);
            callback({
                cancel: true
            });
        } else {
            callback({
                cancel: false
            });
        }
    });
} catch (error) {
    log.error(error);
}
`

var autoGuest =
`autoGuest();

function autoGuest() {
    var buttons = document.getElementsByTagName('button');
    for (var i = 0; i < buttons.length; i++) {
        if (buttons[i].getAttribute('label') == 'Login As Guest') {
            buttons[i].click();
            return;
        }
    }
    setTimeout(autoGuest, 1000);
}
`

module.exports = {
    filterEngine: filterEngine,
    autoGuest: autoGuest
};