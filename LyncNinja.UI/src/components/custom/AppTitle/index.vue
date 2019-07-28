<template>
    <span class='text'>{{ this.$constants.APP_TITLE_VALUE }}</span>
</template>

<script>
    export default {
        name: 'app-title'
    }
</script>

<style scoped>
    @import url('https://fonts.googleapis.com/css?family=MedievalSharp&display=swap');

    .text {
        font-family: 'MedievalSharp', cursive;
        font-size:7em;
        color: white;
        display: flex;
        justify-content: center;
        text-shadow: 0px 1px 0px rgba(255,255,255,.3), 0px -1px 0px rgba(0,0,0,.7);
        margin-bottom: 15px;
    }
</style>
