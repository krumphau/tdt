from application import application
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@application.route('/otherbodies')
@require_appkey
def otherbodies():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllOtherBodies()")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/otherbody/<int:id>', methods=['GET'])
@require_appkey
def otherbody(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetOtherBody(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/otherbody', methods=['POST'])
@require_appkey
def otherbody_add():
    try:
        content = request.json
        _name = content['Name']
        sql = "CALL usp_InsertOtherBody(%s)"
        data = (_name,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/otherbody/<int:id>', methods=['DELETE'])
@require_appkey
def delete_otherbody(id):
    try:
        sql = "CALL usp_DeleteOtherBody(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/otherbody/<int:id>', methods=['PUT'])
@require_appkey
def update_otherbody(id):
    try:
        content = request.json
        _name = content['Name']
        sql = "CALL usp_UpdateOtherBody(%s,%s)"
        data = (id,_name,)        
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)