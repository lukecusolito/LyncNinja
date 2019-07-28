<template>
    <section-container color='#0b1021' minHeight='400px'>
        <app-title />
        <app-description  />
        <div class='input-container'>
            <encoder
                class='input-content' 
                @encoded='encodedOnChange' 
                @decoded='decodedOnChange'
            />
        </div>
        
    </section-container>
</template>

<script>
import AppTitle from '@custom/AppTitle';
import AppDescription from '@custom/AppDescription';
import Encoder from '@custom/Encoder';

export default {
    name: 'top-section',

    components: {
        AppTitle,
        AppDescription,
        Encoder
    },

    methods: {
        encodedOnChange(newVal) {
                this.$emit('encoded', newVal.encodedUrl);
        },

        decodedOnChange(newVal) {
            this.$emit('decoded', newVal.url);
        }
    }
}
</script>

<style scoped>
    .input-container {
        max-width: 100%;
        display: flex;
        justify-content: center;
    }

    .input-content {
        width: 40%;
    }
</style>
