<template>
        <div :id='ID' class='container'>
            <top-section 
                @encoded="encodedOnChange" 
                @decoded="decodedOnChange"/>

            <bottom-section 
                :encodingType='encodingType' 
                :displayUrl='displayUrl' />

            <footer-section />
        </div>
</template>

<script>
import TopSection from './sections/TopSection'
import BottomSection from './sections/BottomSection'
import FooterSection from './sections/FooterSection'

export default {
    name: 'home',

    components: {
        TopSection,
        BottomSection,
        FooterSection
    },

    data () {
        return {
            ID: 'home-page',
            encodingType: null,
            displayUrl: null
        }
    },

    methods: {
        encodedOnChange(newVal) {
            this.encodingType = 'ENCODE';
            this.displayUrl = newVal;
        },

        decodedOnChange(newVal) {
            this.encodingType = 'DECODE';
            this.displayUrl = newVal;
        }
    }
}
</script>

<style scoped>
    .container {
        display: flex;
        flex-direction: column;
        width: 100vw;
        height: 100vh;
    }
</style>
