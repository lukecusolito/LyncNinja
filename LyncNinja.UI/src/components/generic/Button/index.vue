<template>
	<button
		class='button' 
		v-on:click='onClickHandler' >
		
		<div class='shape'></div>
		<p class='text' v-text='text'></p>
	</button>
</template>

<script>
	export default {
		name: 'LyncButton',

		props: {
			text: {
				type: String
			},
			
			onClickHandler: {
				type: Function,
				default: () => null
			}
		}
	}
</script>

<style scoped>
	.button {
		width: 100px;
		min-width: 75px;
		height: 45px;
		outline: 0;
		background: #69132A;
		border: 0;
		cursor: pointer;
		position: relative;
		letter-spacing: 1px;

		-webkit-transition: .2s;
		transition: .2s;
		color: white;
		font-weight:bold;
		box-sizing: border-box;
	}

	.shape {
		height: 20px;
		width: 20px;
		background: darkgrey;
		transform: translate(-50%, -50%) rotate(45deg);
		position: absolute;
		top: 50%;
		left: 50%;
	}

	.button p {
		transform: translate(-50%, -50%);
		position: absolute;
		top: 50%;
		left: 50%;
		color: white;
		margin: 0;
	}

	.button:active {
		/* transform: translateY(2px); */
		background: blue !important;
	}

	.button:hover {
		background: #141c3b;
		-webkit-transition: .2s;
		transition: .2s;
		color: #69132A;
	}
</style>

