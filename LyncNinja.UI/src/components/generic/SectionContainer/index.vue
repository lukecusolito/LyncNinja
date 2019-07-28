<template>
    <section class='section' :class="shadow && 'shadow'" :style="styles">
        <slot></slot>
    </section>
</template>

<script>
    export default {
        name: 'SectionContainer',
        props: {
            color: String,
            shadow: Boolean,
            minHeight: String
        },

        computed: {
            styles () {
                return {
                    backgroundColor: this.color,
                    minHeight: this.minHeight
                }
            },
        }
    }
</script>

<style scoped>
    .section {
        position: relative;
        height: 50%;
        flex-direction: row;
        min-height: 300px;
        display: flex;
        flex-direction: column;
        justify-content: center;
    }

    .section.shadow {
        -webkit-box-shadow: inset 0 7px 10px -6px black;
        -moz-box-shadow: inset 0 7px 10px -6px black;
        box-shadow: inset 0 7px 10px -6px black;
    }
</style>