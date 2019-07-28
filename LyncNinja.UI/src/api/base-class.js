import axios from '@/api/config/axios';

class ApiClass {
    get $http () {
        return axios
    }

    _headers () {
        return {
        }
    }

    _get = async (url, params) => {
        try {
            const result = await this.$http.get(url, {
                headers: this._headers(),
                params
            });
            
            return result && result.data
        } 
        catch (error) {
            return error.response.data
        }
    }
    
    _post = async (url, body) => {
        try {
            var result = await this.$http.post(url, body, {
                headers: this._headers()
            });

            return result && result.data
        } 
        catch (error) {
            return error.response.data
        }
    }
}

export default ApiClass;