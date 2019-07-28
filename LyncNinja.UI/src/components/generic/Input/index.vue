<template>
	<input 
		:disabled='disabled' 
		@input='emitValue' 
		:placeholder='placeholder' 
		v-on:keyup.enter='onClickHandler'/>
</template>

<script>

	export default {
		name: 'LyncInput',

		props: {
			placeholder: {
				type: String
			},
			errorMessage: {
				type: String
			},
			disabled: {
				type: Boolean,
				default: false
			},
			onClickHandler: {
				type: Function,
				default: () => null
			}
		},

		data () {
			return {
				showErrorMessage: false
			}
		},

		methods: {
			emitValue ($event) {   
				const val = $event.target.value === "" ? null : $event.target.value.trim(); 
				this.$emit('input', val);
			}
		}
	}
</script>

<style scoped>
	input {
		height: 45px;
		width: 100%;
		outline: 0;
		color: rgb(29, 31, 33);
		font-size: 100%;
		box-sizing: border-box;
		padding: 0px 15px;
		border: 1px solid rgba(200, 200, 200, .5);
		box-shadow: inset 0 1px 2px rgba(10,10,10,.1);
		border-radius:  0px 0px 0px 40px
	} 

	input:focus {
		transition: all 0.2s ease-in;
		border-color: plum;
	}

	input:disabled {
		background-color: white;
	}
</style>

