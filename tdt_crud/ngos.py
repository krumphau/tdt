from application import application
from flask import flash, request
import sqlhelper

@application.route('/ngos')
def ngos():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllNGOs")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/ngo/<int:id>', methods=['GET'])
def ngo(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetNGO(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/ngo', methods=['POST'])
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