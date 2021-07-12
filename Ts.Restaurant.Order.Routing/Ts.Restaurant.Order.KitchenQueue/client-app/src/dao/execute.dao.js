import axios from 'axios';

const client = axios.create({});

export default {
   async execute(method, resourceUrl, data, params) {
      return client({
         method: method,
         url: resourceUrl,
         data: data,
         params: params,
         headers: {
            'Content-Type': "application/json"
         }
      })
         .then(resp => {
            return resp.data;
         })
         .catch(error => { return error });
   }
}