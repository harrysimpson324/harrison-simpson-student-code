// middleware to convert PascalCase to camelCase from .NET client
module.exports = (req, res, next) => {
  const regexStartsWithCapital = new RegExp('^[A-Z]');
  for (var prop in req.body) {
    if (Object.prototype.hasOwnProperty.call(req.body, prop)) {
      if (regexStartsWithCapital.test(prop)) {
        camelProp = prop.charAt(0).toLowerCase() + prop.slice(1);
        req.body[camelProp] = req.body[prop]
        delete req.body[prop]
      }
    }
  }
  next()
}