<template>
    <div class='container'>
        <lync-input
            class='input'
            v-model='inputValue'
            :onClickHandler='onClickEncode'
            :placeholder='inputPlaceholder'
        />
        <lync-button
            :text='encodeButtonLabel'
            :onClickHandler='onClickEncode'
        />
        <lync-button
            :text='decodeButtonLabel'
            :onClickHandler='onClickDecode'
        />
    </div>
</template>

<script>
    export default {
        name: 'Encoder',

        data () {
            return {
                encodeButtonLabel: this.$constants.ENCODER_ENCODE_BUTTON_LABEL,
                decodeButtonLabel: this.$constants.ENCODER_DECODE_BUTTON_LABEL,
                inputPlaceholder: this.$constants.PAGE_HOME_DEFAULT_DISPLAY_MESSAGE,
                inputValue: null,
            }
        },

        methods: {
            async onClickEncode() {
                if(!this.hasValue)
                    return;

                try {
                    const result = await this.$api.link.createLink(this.inputValue);
                    this.$emit('encoded', result);
                }
                catch (err) {
                    console.log(err)
                }
            },

            async onClickDecode() {
                if(!this.hasValue)
                    return;

                try {
                    var keyValue = this.inputValue.substring(this.inputValue.lastIndexOf("/") + 1);

                    const result = await this.$api.link.retrieveLink(keyValue);
                    this.$emit('decoded', result);
                }
                catch (err) {
                    console.log(err)
                }
            }
        },

        computed: {
            hasValue() {
                return this.inputValue && this.inputValue !== '';
            }
        }
    }
</script>

<style scoped>
    .container {
        width: 600px;
        min-width: 300px;
        height: 50px;
        display: flex;
    }

    .input {
        width: 100%;
    }
</style>
