from app import app
from flask import flash, request
import sqlhelper

@app.route('/projects')
def projects():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllProjects")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/project/<int:id>', methods=['GET'])
def project(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetProject(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/project', methods=['POST'])
def project_add():
    try:
        content = request.json
        _firstName = content['FirstName']
        _lastName = content['LastName']
        _tel = content['Tel']
        _mob = content['Mobile']
        _add1 = content['Address1']
        _add2 = content['Address2']
        _add3 = content['Address3']
        _town = content['Town']
        _county = content['County']
        _postcode = content['PostCode']
        _maincontact = content['MainContact']
        _image = content['Image']
        _info = content['Info']
        sql = "CALL usp_InsertProject(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (_firstName,_lastName,_tel,_mob,_add1,_add2,_add3,_town,_county,_postcode,_maincontact,_image,_info,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/project/<int:id>', methods=['DELETE'])
def delete_project(id):
    try:
        sql = "CALL usp_DeleteProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/project/<int:id>', methods=['PUT'])
def update_project(id):
    try:
        content = request.json
        _firstName = content['FirstName']
        _lastName = content['LastName']
        _tel = content['Tel']
        _mob = content['Mobile']
        _add1 = content['Address1']
        _add2 = content['Address2']
        _add3 = content['Address3']
        _town = content['Town']
        _county = content['County']
        _postcode = content['PostCode']
        _maincontact = content['MainContact']
        _image = content['Image']
        _info = content['Info']

        sql = "CALL usp_UpdateProject(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (id,_firstName,_lastName,_tel,_mob,_add1,_add2,_add3,_town,_county,_postcode,_maincontact,_image,_info,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)
