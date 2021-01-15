namespace Blitz_Patcher
{
    class JS
    {
        #region FilterEngine

        #region Not done area



        /*
              fs.readFileSync(require.resolve('./easylist.txt'), 'utf-8') + '\\n'
                fs.readFileSync(require.resolve('./easyprivacy.txt'), 'utf-8') + '\\n'
                fs.readFileSync(require.resolve('./ublock-ads.txt'), 'utf-8') + '\\n'
                fs.readFileSync(require.resolve('./ublock-privacy.txt'), 'utf-8') + '\\n'
                fs.readFileSync(require.resolve('./peter-lowe-list.txt'), 'utf-8') + '\\ngoogleoptimize.com\\n';
         */

        /*
        const string EasyListFile = @"fs.readFileSync(require.resolve('./easylist.txt'), 'utf-8') + '\\n'";
        const string EasyPrivacyFile = @"fs.readFileSync(require.resolve('./easyprivacy.txt'), 'utf-8') + '\\n'";
        const string UBlockAdsFile = @"fs.readFileSync(require.resolve('./ublock-ads.txt'), 'utf-8') + '\\n'";
        const string UBlockPrivacyFile = @"fs.readFileSync(require.resolve('./ublock-privacy.txt'), 'utf-8') + '\\n'";
        const string PeterLoweFile = @"fs.readFileSync(require.resolve('./peter-lowe-list.txt'), 'utf-8')";

        public static string GetFilterScript(bool easyList = true, bool easyPrivacy = true, bool uBlockAds = true, bool uBlockPrivacy = true, bool peterLowe = true)
        {
            var tmp = FilterEngine;
            tmp = tmp.Replace("{0}", easyList ? EasyListFile : "");
            tmp = tmp.Replace("{1}", easyPrivacy ? EasyPrivacyFile : "");
            tmp = tmp.Replace("{2}", uBlockAds ? UBlockAdsFile : "");
            tmp = tmp.Replace("{3}", uBlockPrivacy ? UBlockPrivacyFile : "");
            tmp = tmp.Replace("{4}", peterLowe ? PeterLoweFile : "");
            return tmp;
        }
        */
        #endregion

        public const string FilterEngine = @"
            try {
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
        ";
        #endregion
        #region AutoGuest
        public const string AutoGuest = @"
            autoGuest();

            function autoGuest() {
                var buttons = document.getElementsByTagName('button');
                for (var i = 0; i < buttons.length; i++) {
                    if (buttons[i].getAttribute('label') == 'Login As Guest') {
                        buttons[i].click();
                        return;
                    }
                }
                setTimeout(autoGuest, 1000);
            }";
        #endregion
    }
}
