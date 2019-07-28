<template>
    <section-container color='#fafafa' shadow>
        <div class='content-container' v-if='displayUrlIsSet'>
            <lync-label 
                :text='displayMessage'
                class='label' />
            <div class='url-container'>
                <lync-label 
                    :text='displayUrl' />
                <button
                    :text='$constants.PAGE_HOME_COPY_BUTTON_LABEL' 
                    class='url-copy-button' 
                    v-on:click="onCopyClickHandler" >
                    
                    <lync-label
                        v-text='$constants.PAGE_HOME_COPY_BUTTON_LABEL' />
                </button>
                    <!-- v-on:click= "select($event)"-->
            </div>
        </div>
        <div class='ninja-container'>
            <ninja class='ninja' />
        </div>
    </section-container>
</template>

<script>
    import Ninja from '@custom/Ninja';

    export default {
        name: 'bottom-section',
        components: {
            Ninja
        },
        
        props: {
            encodingType: {
                type: String
            },
            displayUrl: {
                type: String
            }
        },

        data () {
            return {
                displayMessage: this.$constants.PAGE_HOME_DEFAULT_DISPLAY_MESSAGE,
            }
        },

        watch: {
            encodingType(val) {
                if(val === 'DECODE')
                    this.displayMessage = this.$constants.PAGE_HOME_DECODE_DISPLAY_MESSAGE;
                else
                    this.displayMessage = this.$constants.PAGE_HOME_ENCODE_DISPLAY_MESSAGE;
            },
        },

        computed: {
            displayUrlIsSet() {
                return this.displayUrl !== null
            }
        },

        methods: {
            onCopyClickHandler() {
                const textField = document.createElement('textarea');
                textField.innerText = this.displayUrl;
                document.body.appendChild(textField);
                textField.select();
                document.execCommand('copy');
                textField.remove();
            }
        }
    }
</script>

<style scoped>
    .content-container {
        width: 100%;
        display: flex;
        flex: 1;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }
    
    .input-container {
        padding: 10px;
        display: flex;
        justify-content: center;
    }
    
    .display-message {
        height: 30px;
    }    

    .ninja-container {
        display: flex;
        position: absolute;
        bottom: 0;
        right: 100px;
    }

    .ninja {
        width: 150px;
    }

    .url-container {
        display:flex;
        flex-direction: row;
        font-weight: bold;
    }

    .url-copy-button {
        cursor: pointer;
        margin-left: 15px;
        background: transparent;
        outline: 0;
        border: 0;
        margin-bottom: 15px;
        color: blue;
    }

    .url-copy-button:active {
		-webkit-transition: .2s;
		transition: .2s;
        transform: translateY(-5px);
    }
</style>
