module.exports = {
    root: true,
    env: {
        node: true,
    },
    extends: [
        'plugin:vue/vue3-essential',
        'eslint:recommended',
    ],
    parserOptions: {
        parser: '@babel/eslint-parser',
    },
    rules: {
        // Your specific ESLint rules go here
    },
    overrides: [
        {
            files: ['**/*.js', '**/*.vue'], // Add the file extensions you want
            extends: [
                'plugin:vue/vue3-essential',
                'eslint:recommended',
            ],
            parserOptions: {
                parser: '@babel/eslint-parser',
            },
            rules: {
                // Your specific ESLint rules for these file types go here
            },
        },
    ],
};
