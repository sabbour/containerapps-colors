var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  console.log("Home");
  res.render('index', { title: 'Azure Container Apps is awesome!'});
});

module.exports = router;
