import GenericComponents from './components/generic'

const COMPONENTS = {
    ...GenericComponents
};

export default {
    install(Vue) {
        Object.values(COMPONENTS).forEach(component => Vue.component(component.name, component));
    }
}