const { PurgeCSSPlugin } = require('purgecss-webpack-plugin');

const { BundleAnalyzerPlugin } = require('webpack-bundle-analyzer');

const glob = require('glob');
const path = require('path');

module.exports = {
  plugins: [
    new PurgeCSSPlugin({
      paths: glob.sync(`${path.join(__dirname, 'src')}/**/*`, { nodir: true }),
      // Add other PurgeCSS options as needed
    }),
    new BundleAnalyzerPlugin({
      analyzerMode: 'static' // This opens an HTML file with the bundle report
    })
  ]
};
