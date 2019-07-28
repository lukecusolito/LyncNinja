<template>
    <a :href='$constants.GITHUB_ADDRESS' :alt='$constants.GITHUB_ALT' >
        <img src='../../../assets/github-icon.jpg'/>
    </a>
</template>

<script>
    export default {
        name: 'github'
    }
</script>

<style scoped>
    img {
        width: 100%;
        height: 100%;
        cursor: pointer;
    }
</style>
