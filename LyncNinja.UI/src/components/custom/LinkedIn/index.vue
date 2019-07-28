<template>
    <a :href='$constants.LINKEDIN_ADDRESS' :alt='$constants.LINKEDIN_ALT' >
        <img src='../../../assets/linkedin-icon.png' />
    </a>
</template>

<script>
    export default {
        name: 'linkedin'    
    }
</script>

<style scoped>
    img {
        width: 100%;
        height: 100%;
        cursor: pointer;
    }
</style>
