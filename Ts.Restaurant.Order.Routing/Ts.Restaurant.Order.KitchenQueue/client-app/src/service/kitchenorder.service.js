import dao from '../dao/execute.dao';

export default {
   async getOrders() {
      var url = 'https://' + window.location.host + '/LastOrder';
      var result = await dao.execute('get', url)
      return result;
   }
}