<template>
    <img src='../../../assets/ninja.png' :class="rotate && 'rotate'"  alt='Ninja'/>
</template>

<script>
// import config from 'config.json'
// const config = {
//     "valid_rotations": ["left", "up"]
// }

    export default {
        name: 'ninja',
        
        props: {
            // rotate: {
            //     type: String,
            //     default: 'left',
            //     validator: rotation => {
            //         return config.valid_rotations.includes(rotation)
            //     }
            // }
            rotate: {
                type: Boolean
            }
        }
    }
</script>

<style scoped>
    .rotate {
        -webkit-transform: translateY(-100%) rotate(90deg); 
        -moz-transform: translateY(-100%) rotate(90deg); 
        -ms-transform: translateY(-100%) rotate(90deg);
        -o-transform: translateY(-100%) rotate(90deg); 
        transform: translateY(-100%) rotate(90deg);
        -webkit-transform-origin: left bottom;
        -moz-transform-origin: left bottom;
        -ms-transform-origin: left bottom;
        -o-transform-origin: left bottom;
        transform-origin: left bottom;
    }
</style>
