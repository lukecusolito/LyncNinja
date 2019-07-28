<template>
	<span class='lync-label' v-text="text" />
</template>

<script>
	export default {
		name: 'LyncLabel',

		props: {
			text: {
				type: String
			}
		}
	}
</script>

<style scoped>
	.lync-label {
		margin-bottom: 15px;
	}
</style>

