var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

router.get('/search', function(req, res, next) {
  res.render('search', { title: 'Express' });
});

router.get('/one-way-flights', function(req, res, next) {
  res.render('flights-oneway', { title: 'Express' });
});

router.get('/round-trip-flights', function(req, res, next) {
  res.render('flights-roundtrip', { title: 'Express' });
});

router.get('/passengers', function(req, res, next) {
  res.render('passengers', { title: 'Express' });
});

router.get('/seats', function(req, res, next) {
  res.render('seats', { title: 'Express' });
});

router.get('/payment', function(req, res, next) {
  res.render('payment', { title: 'Express' });
});

router.get('/admin/flights', function(req, res, next) {
  res.render('admin-flights', { title: 'Express' });
});

router.get('/admin/bookings', function(req, res, next) {
  res.render('admin-bookings', { title: 'Express' });
});

module.exports = router;
