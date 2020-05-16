from application import application
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@application.route('/ngos')
@require_appkey
def ngos():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllNGOs")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/ngo/<int:id>', methods=['GET'])
@require_appkey
def ngo(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetNGO(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/ngo', methods=['POST'])
@require_appkey
def ngo_add():
    try:
        content = request.json
        _name = content['Name']
        sql = "CALL usp_InsertNGO(%s)"
        data = (_name,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/ngo/<int:id>', methods=['DELETE'])
@require_appkey
def delete_ngo(id):
    try:
        sql = "CALL usp_DeleteNGO(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/ngo/<int:id>', methods=['PUT'])
@require_appkey
def update_ngo(id):
    try:
        content = request.json
        _name = content['Name']
        sql = "CALL usp_UpdateNGO(%s,%s)"
        data = (id,_name,)        
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)