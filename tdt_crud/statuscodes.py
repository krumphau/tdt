from application import application
from flask import flash, request
import sqlhelper

@application.route('/statuscodes')
def statuscodes():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllProjectStatusCodes()")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/statuscode/<int:id>', methods=['GET'])
def statuscode(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetStatusCode(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/statuscode', methods=['POST'])
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

@application.route('/statuscode/<int:id>', methods=['DELETE'])
def delete_statuscode(id):
    try:
        sql = "CALL usp_DeleteStatusCode(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/statuscode/<int:id>', methods=['PUT'])
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