from application import application
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@application.route('/user/<string:email>', methods=['GET'])
@require_appkey
def get_user(email):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetUser(%s)", email)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)