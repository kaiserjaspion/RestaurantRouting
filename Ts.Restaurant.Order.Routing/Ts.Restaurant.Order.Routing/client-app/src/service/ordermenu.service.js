import dao from '../dao/execute.dao';

export default {
   async getMenu() {
      var url = 'https://' + window.location.host + '/Menu';
      var result = await dao.execute('get', url)
      return result;
   },
   async postMenu(item) {
      var url = 'https://' + window.location.host + '/SendOrder';
      var result = await dao.execute('post', url, item)
      return result;
   },
}