from application import application
from flask import flash, request
import sqlhelper

@application.route('/regions')
def regions():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllRegions")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/region/<int:id>', methods=['GET'])
def region(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetRegion(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/region', methods=['POST'])
def region_add():
    try:
        content = request.json
        _name = content['Name']
        sql = "CALL usp_InsertRegion(%s)"
        data = (_name,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/region/<int:id>', methods=['DELETE'])
def delete_region(id):
    try:
        sql = "CALL usp_DeleteRegion(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/region/<int:id>', methods=['PUT'])
def update_region(id):
    try:
        content = request.json
        _name = content['Name']
        sql = "CALL usp_UpdateRegion(%s,%s)"
        data = (id,_name,)        
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)
