# Blitz App Adblock

A simple and quick patcher that blocks ads/trackers on the Blitz.gg desktop application.

If Blitz.gg updates, you will need to rerun the program to reapply the patch. 

If there are issues even after a clean install, [submit a Github issue](https://github.com/lulzsun/blitz-app-adblock/issues/new) and optionally attach the following log file: 

`%appdata%/Blitz/app.log`

You can uninstall the adblocker by uninstalling Blitz.

## Install

Download latest release [here](https://github.com/lulzsun/blitz-app-adblock/releases/latest).

Extract .zip and open `blitz-app-adblock` executable.

## Install & Build (Developer)

Requires Node 10 or later. 

```bash
$ npm install
$ npm run build
```

Builds standalone to `.\build\Release\` using [pkg](https://github.com/vercel/pkg)

## Optional Features

You can run the program with the following arguments to use some optional features:

- `-noupdate` - Disables check to auto updater on launch
- `-autoguest` - Enables auto login as guest if no account is saved

## Disclaimer

Using this is against Blitz.gg's terms of services. I am not responsible for what happens to your Blitz.gg account, you have been warned.

## Special thanks to

[asar - electron archive](https://github.com/electron/asar)

[pgk - single-command Node.js binary compiler](https://github.com/vercel/pkg)

[Easylist - filters for ads/trackers](https://easylist.to/pages/about.html)

[uAssets - filters for ads/trackers](https://github.com/uBlockOrigin/uAssets)

[Cliqz' adblocker - js library for blocking ads/trackers](https://github.com/cliqz-oss/adblocker)
