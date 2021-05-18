# Blitz App Adblock

A simple and quick patcher that blocks ads/trackers on the Blitz.gg desktop application (supports Mac and Windows).

If Blitz.gg updates, you will need to rerun the program to reapply the patch. 

If there are issues after an update, [submit a Github issue](https://github.com/lulzsun/blitz-app-adblock/issues/new) and attach useful information such as error messages.

You can uninstall the adblocker by uninstalling Blitz.

## Install
Download latest release [here](https://github.com/lulzsun/blitz-app-adblock/releases/latest). Make sure to have the Blitz app completely closed before beginning.

### Windows
1. Extract .zip
2. Run `blitz-app-adblock.exe`

If issues occur, try to run executable as administrator.

### Mac
1. Extract .zip
2. Open terminal and enter the following commands
```bash
$ cd "insert directory of blitz-app-adblock-mac"
$ chmod +x blitz-app-adblock-mac
$ ./blitz-app-adblock-mac
```

## Install & Build (Developer)

Built for Node 14.15.4 (recommended).

```bash
$ npm install
$ npm run build
```

Builds standalone to `.\build\` using [pkg](https://github.com/vercel/pkg).

## Optional Features

You can run the program with the following arguments to use some optional features:

- `-noupdate` - Disables check to auto updater on launch
- `-autoguest` - Enables auto login as guest if no account is saved

## Disclaimer

Using this is against Blitz.gg's terms of services. I am not responsible for what happens to your Blitz.gg account, you have been warned.

## Special thanks to

[asar - electron archive](https://github.com/electron/asar)

[pkg - single-command Node.js binary compiler](https://github.com/vercel/pkg)

[Easylist - filters for ads/trackers](https://easylist.to/pages/about.html)

[uAssets - filters for ads/trackers](https://github.com/uBlockOrigin/uAssets)

[Cliqz' adblocker - js library for blocking ads/trackers](https://github.com/cliqz-oss/adblocker)
