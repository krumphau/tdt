from app import app
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@app.route('/statuscodes')
@require_appkey
def statuscodes():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllProjectStatusCodes()")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/statuscode/<int:id>', methods=['GET'])
@require_appkey
def statuscode(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetStatusCode(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/statuscode', methods=['POST'])
@require_appkey
def statuscode_add():
    try:
        content = request.json
        
        _code = content['StatusCode']
        _desc = content['Description']

        sql = "CALL usp_InsertStatusCode(%s,%s)"
        data = (_code,_desc,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/statuscode/<int:id>', methods=['DELETE'])
@require_appkey
def delete_statuscode(id):
    try:
        sql = "CALL usp_DeleteStatusCode(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/statuscode/<int:id>', methods=['PUT'])
@require_appkey
def update_statuscode(id):
    try:
        content = request.json
        _code = content['StatusCode']
        _desc = content['Description']
        sql = "CALL usp_UpdateStatusCode(%s,%s,%s)"
        data = (id,_code,_desc,)        
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)