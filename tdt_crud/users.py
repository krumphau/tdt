from app import app
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@app.route('/user/<string:email>', methods=['GET'])
@require_appkey
def get_user(email):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetUser(%s)", email)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)