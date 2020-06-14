from app import app
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@app.route('/districts')
@require_appkey
def districts():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllDistricts()")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/district/<int:id>', methods=['GET'])
@require_appkey
def district(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetDistrict(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/district', methods=['POST'])
@require_appkey
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

@app.route('/district/<int:id>', methods=['DELETE'])
@require_appkey
def delete_district(id):
    try:
        sql = "CALL usp_DeleteDistrict(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/district/<int:id>', methods=['PUT'])
@require_appkey
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
