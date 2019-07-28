import Api from '../base-class';

class LinkApi extends Api {
    controller = 'Link';
    
    createLink = async (url) => (
        await this._post(this.controller + '/', {
            Url: url,
        })
    )

    retrieveLink = async (key) => (
        await this._get(this.controller + '/' + key)
    )
}

export default new LinkApi()