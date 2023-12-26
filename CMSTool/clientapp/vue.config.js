const path = require('path');

module.exports = {
    outputDir: path.resolve(__dirname, '../wwwroot/clientapp'),
    publicPath: '/clientapp/', // Make sure it ends with a forward slash

    devServer: {
        proxy: {
            '/api': {
                target: 'http://localhost:5000',  // Replace with your ASP.NET Core API URL
                changeOrigin: true
            }
        }
    },

    chainWebpack: config => {
        // Use vue-loader for *.vue files
        config.module
            .rule('vue')
            .use('vue-loader')
            .loader('vue-loader')
            .end();
    }
};
