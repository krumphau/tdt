from application import application
from flask import flash, request
import sqlhelper

@application.route('/districts')
def districts():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllDistricts()")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/district/<int:id>', methods=['GET'])
def district(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetDistrict(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/district', methods=['POST'])
def district_add():
    try:
        content = request.json
        _name = content['Name']
        sql = "CALL usp_InsertDistrict(%s)"
        data = (_name,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/district/<int:id>', methods=['DELETE'])
def delete_district(id):
    try:
        sql = "CALL usp_DeleteDistrict(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/district/<int:id>', methods=['PUT'])
def update_district(id):
    try:
        content = request.json
        _name = content['Name']
        sql = "CALL usp_UpdateDistrict(%s,%s)"
        data = (id,_name,)        
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)
