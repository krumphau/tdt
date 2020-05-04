from application import application
from flask import flash, request
import sqlhelper

@application.route('/projectofficers')
def projectofficers():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllProjectOfficers")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/projectofficer/<int:id>', methods=['GET'])
def projectofficer(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetProjectOfficer(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/projectofficer', methods=['POST'])
def projectofficer_add():
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
        _image = content['Image']
        _info = content['Info']
        _email = content['Email']
        sql = "CALL usp_InsertProjectOfficer(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (_firstName,_lastName,_tel,_mob,_email,_add1,_add2,_add3,_town,_county,_postcode,_image,_info)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/projectofficer/<int:id>', methods=['DELETE'])
def delete_projectofficer(id):
    try:
        sql = "CALL usp_DeleteProjectOfficer(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/projectofficer/<int:id>', methods=['PUT'])
def update_projectofficer(id):
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

        sql = "CALL usp_UpdateProjectOfficer(%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s,%s)"
        data = (id,_firstName,_lastName,_tel,_mob,_add1,_add2,_add3,_town,_county,_postcode,_maincontact,_image,_info,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)
