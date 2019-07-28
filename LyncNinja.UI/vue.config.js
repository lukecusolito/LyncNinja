const path = require('path')
module.exports = {
    chainWebpack: config => {
        config.resolve.alias
            .set('@', path.resolve(__dirname, 'src'))
            .set('@custom', path.resolve(__dirname, 'src/components/custom'))
    }
}