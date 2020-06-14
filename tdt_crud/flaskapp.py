import pymysql
from db_config import mysql
from flask import flash, request, jsonify
from app import app
import categories
import districts
import funders
import ngos
import otherbodies
import projectofficers
import regions
import statuscodes
import projectcategories
import projectfunders
import projectdocuments
import projectngos
import projectotherbodies
import projectpurchaseditems
import projectrelatedprojects
import projectvisits
import projects
import searchprojects
import test
import users

@app.errorhandler(404)
def not_found(error=None):
    message = {
        'status': 404,
        'message': 'Not Found: ' + request.url,
    }
    resp = jsonify(message)
    resp.status_code = 404

    return resp

@app.route('/')
def hello_world():
  return 'Hello from TDT API!'

if __name__ == "__main__":
    app.run(host='0.0.0.0', port=80)