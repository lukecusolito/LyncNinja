import axios from 'axios';

const instance = axios.create({
    baseURL: 'http://localhost:19765/api/',
    timeout: 30000,
    headers: {
        'Access-Control-Allow-Origin': '*'
    }
});

export default instance;