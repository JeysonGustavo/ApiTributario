using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Manager
{
    public class HttpClientHelper
    {
        #region Propriedades
        private HttpClient _client;
        private StringContent _content;
        private Encoding _encoding;
        private string _mediaType;
        private string _endpoint;
        #endregion

        #region Construtor
        /// <summary>
        /// Http Client Helper
        /// </summary>
        /// <param name="client"></param>
        public HttpClientHelper(HttpClient client)
        {
            _client = client;
            _encoding = Encoding.UTF8;
            _mediaType = "application/json";
        }

        public HttpClientHelper()
        {
        }
        #endregion

        #region Serialize
        /// <summary>
        /// Serializa o objeto para JSON
        /// </summary>
        /// <param name="o">Objeto a ser serializado</param>
        /// <returns>Objeto serializado no tipo string</returns>
        public string Serialize<T>(T o)
            => JsonConvert.SerializeObject(o);
        #endregion

        #region Deserialize
        /// <summary>
        /// Deserealiza JSON para objeto
        /// </summary>
        /// <param name="Json">Json a ser desserializado</param>
        /// <returns>Objeto desserializado no tipo T</returns>
        public T Deserialize<T>(string Json)
            => JsonConvert.DeserializeObject<T>(Json);
        #endregion

        #region With Content Serialized
        /// <summary>
        /// Convert para Json o objeto a ser enviado
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public HttpClientHelper WithContentSerialized<T>(T o)
        {
            _content = new StringContent(Serialize(o), _encoding, _mediaType);
            return this;
        }
        #endregion

        #region With Content
        /// <summary>
        /// Converte o objeto para ser enviado
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public HttpClientHelper WithContent(object o)
        {
            _content = new StringContent(o.ToString(), _encoding, _mediaType);
            return this;
        }
        #endregion

        #region Set End Point
        /// <summary>
        /// Seta o end point
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public HttpClientHelper SetEndpoint(string endpoint)
        {
            _endpoint = endpoint;
            return this;
        }
        #endregion

        #region Set Token
        /// <summary>
        /// Seta o Token
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns></returns>
        public HttpClientHelper SetToken(string token)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", token);
            return this;
        }
        #endregion

        #region Http Methods
        /// <summary>
        /// Get Async
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync()
            => await _client.GetAsync(_endpoint);

        /// <summary>
        /// Post Async
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsync()
            => await _client.PostAsync(_endpoint, _content);

        /// <summary>
        /// Put Async
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PutAsync()
            => await _client.PutAsync(_endpoint, _content);

        /// <summary>
        /// Delete Async
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteAsync()
            => await _client.DeleteAsync(_endpoint);
        #endregion
    }
}
