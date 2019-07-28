<template>
    <span class='text'>{{ this.$constants.APP_DESCRIPTION_VALUE }}</span>
</template>

<script>
    export default {
        name: 'app-description',
    }
</script>

<style scoped>
    .text {
        font-size:1em;
        color: white;
        display: flex;
        justify-content: center;
        margin-bottom: 30px;
    }
</style>
