<template>
	<div id='app'>
		<router-view />
	</div>
</template>

<script>
	export default {
		name: 'app',

		mounted() {
			if(!this.$route.params.urlKey)
				this.$router.push('/');
		}
	}
</script>

<style>
	#app {
		font-family: 'Avenir', Helvetica, Arial, sans-serif;
		display: flex;
		overflow-y: auto;
	}

	body {
		margin: 0 !important
	}

	/* top shaddow */
	body:before {
		content: '';
		position: fixed;
		top: -10px;
		left: 0;
		width: 100%;
		height: 10px;

		-webkit-box-shadow: 0px 0px 10px rgba(0,0,0,.5);
		-moz-box-shadow: 0px 0px 10px rgba(0,0,0,.5);
		box-shadow: 0px 0px 10px rgba(0,0,0,.5);

		z-index: 100;
	}
</style>
