<template>
    <div >
        <div v-if='showNotFound' class='page-container'>
            <ninja class='ninja' />
            <div class='bubble'>
                <div class='title'>{{$constants.PAGE_URL_RESOLVER_TITLE}}</div>  
                <div class='message'>{{$constants.PAGE_URL_RESOLVER_MESSAGE}}</div>  
            </div>          
        </div>
    </div>
</template>

<script>
    import Ninja from '@custom/Ninja';

    export default {
        name: 'UrlResolver',

        components:{
            Ninja
        },

        data () {
            return {
                showNotFound: false,
                urlResult: null
            }
        },

        async mounted () {
            try {
                var urlKey = this.$route.params.urlKey;

                this.urlResult = await this.$api.link.retrieveLink(urlKey);
            } catch { 
                this.displayNotFound();
            }
        },

        methods:{ 
            displayNotFound() {
                this.showNotFound = true;
            },

            redirectToUrl() {
                location.replace(this.urlResult.url);
            },
        },

        watch: {
            urlResult() {
                if(this.urlResultHasErrors)
                    this.displayNotFound();
                else
                    this.redirectToUrl();
            }
        },

        computed: {
            urlResultHasErrors() {
                return !!(this.urlResult && this.urlResult.errors);
            }
        }
    }
</script>

<style scoped>
    .page-container {
        background-color: #0b1021;
        width: 100vw;
        height: 100vh;
    }

    .ninja {
        
        width: 20vw;
        -webkit-transform: rotate(180deg); 
        -moz-transform: rotate(180deg); 
        -ms-transform: rotate(180deg);
        -o-transform: rotate(180deg); 
        transform: rotate(180deg);
    }

    .message {
        text-align: center;
        height: 100%;
        width: 100%;
        font-size: 2vw;
        display: flex;
        justify-content:center;
        align-content:center;
        flex-direction:column;
    }

    .title {
        position: absolute;
        font-size: 6vw
    }

    .bubble {
        top:0;
        bottom: 0;
        left: 0;
        right: 0;
        margin: auto;

        position: absolute;
        width: 30vw;
        height: 20vw;
        padding: 0px;
        color: white;
    }
</style>
