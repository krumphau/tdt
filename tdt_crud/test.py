from app import app
from flask import flash, request, jsonify

@app.route('/test')
def test():
    try:
        resp = jsonify('App is healthy')
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)