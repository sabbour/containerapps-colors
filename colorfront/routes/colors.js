var express = require('express');
var router = express.Router();
const axios = require('axios').default;

// use dapr http proxy (header) to call color service
const daprPort = process.env.DAPR_HTTP_PORT || 3500;
const daprSidecar = `http://localhost:${daprPort}`

/* GET call the color microservice and get an updated color */
router.get('/', async function (req, res, next) {
  var url = `${daprSidecar}/v1.0/invoke/colorservice/method/getcolor?timestamp=${Date.now()}`;
  try {
    const response = await axios.get(url);
    res.json(response.data);
  } catch (err) {
    if (err.response) {
      console.log(`Error: ${err.response.data?.message}`);  
    }
  }
});


module.exports = router;
