from application import application
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@application.route('/funders')
@require_appkey
def funders():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllFunders()")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/funder/<int:id>', methods=['GET'])
@require_appkey
def funder(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetFunders(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/funder', methods=['POST'])
@require_appkey
def funder_add():
    try:
        content = request.json        
        _name = content['Name']
        _add1 = content['Address1']
        _add2 = content['Address2']
        _add3 = content['Address3']
        _town = content['Town']
        _county = content['County']
        _postcode = content['PostCode']
        _tel = content['Tel']
        _maincontact = content['MainContact']
        _amount = content['Amount']
        sql = "CALL usp_InsertFunder(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (_name,_add1,_add2,_add3,_town,_county,_postcode,_tel,_maincontact,_amount,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/funder/<int:id>', methods=['DELETE'])
@require_appkey
def delete_funder(id):
    try:
        sql = "CALL usp_DeleteFunder(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/funder/<int:id>', methods=['PUT'])
@require_appkey
def update_funder(id):
    try:
        content = request.json
        _name = content['Name']
        _add1 = content['Address1']
        _add2 = content['Address2']
        _add3 = content['Address3']
        _town = content['Town']
        _county = content['County']
        _postcode = content['PostCode']
        _tel = content['Tel']
        _maincontact = content['MainContact']
        _amount = content['Amount']

        sql = "CALL usp_UpdateFunder(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (id,_name,_add1,_add2,_add3,_town,_county,_postcode,_tel,_maincontact,_amount,)        
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)
