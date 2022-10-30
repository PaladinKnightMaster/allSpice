module.exports = {
  root: true,

  env: {
    node: true
  },

  extends: [
    'plugin:vue/vue3-strongly-recommended',
    '@vue/standard'
  ],

  parserOptions: {
    ecmaVersion: 2020
  },

  rules: {
    'no-unused-vars': 1,
    'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'space-before-function-paren': [1, 'never'],
    'vue/max-attributes-per-line': ['error', {
      singleline: {
        max: 3
      },
      multiline: {
        max: 1
      }
    }],
    'vue/html-self-closing': 0,
    'vue/multi-word-component-names': 'off'
  }
}
