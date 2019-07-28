
import HomePage from '../pages/PageHome';
import PageUrlResolver from '../pages/PageUrlResolver';

const routes = [
    {
        path: '/',
        name: 'Lync Ninja',
        component: HomePage
    },
    {
        path: '/:urlKey',
        name: 'Resolving',
        component: PageUrlResolver
    }
]

export default routes;