<template>
    <footer>
        <div class='container'>
            <div class='icon'>
                <git-hub />
            </div>
            <div class='icon'>
                <linked-in />
            </div>
        </div>
    </footer>
</template>

<script>
    import GitHub from '@custom/GitHub';
    import LinkedIn from '@custom/LinkedIn';

    export default {
        name: 'footer-section',
        
        components: {
            GitHub,
            LinkedIn
        }
    }
</script>

<style scoped>
    .container {
        height: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .icon {
        width: 30px;
        height: 30px;
        margin-right: 15px;
    }
    /* .icon:not(:first-child) {
        margin-right: 0px;
    } */
    .icon:last-child {
        margin-right: 0px;
    }

    footer {
        height: 75px;
        min-height: 75px;
        flex-direction: row;
        background-color: #0b1021;
    }
</style>
