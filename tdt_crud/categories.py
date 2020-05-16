from application import application
from flask import flash, request, jsonify
import sqlhelper
from authhelper import require_appkey

@application.route('/categories')
@require_appkey
def categories():
    try:
        resp = sqlhelper.do_selectmulti("CALL usp_GetAllCategories()")
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/category/<int:id>', methods=['GET'])
@require_appkey
def category(id):
    try:
        resp = sqlhelper.do_selectsinglebyid("CALL usp_GetCategory(%s)", id)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/category', methods=['POST'])
@require_appkey
def category_add():
    try:
        content = request.json
        _name = content['CategoryName']

        _highlevel = content['HighLevelCategory'] if 'HighLevelCategory' in content else 0

        sql = "CALL usp_InsertCategory(%s, %s)"
        data = (_name, _highlevel,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/category/<int:id>', methods=['DELETE'])
@require_appkey
def delete_category(id):
    try:
        sql = "CALL usp_DeleteCategory(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/category/<int:id>', methods=['PUT'])
@require_appkey
def update_category(id):
    try:
        content = request.json
        _name = content['CategoryName']
        _highlevel = content['HighLevelCategory'] if 'HighLevelCategory' in content else 0

        sql = "CALL usp_UpdateCategory(%s, %s, %s)"
        data = (id,_name,_highlevel,)        
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return request.json
    except Exception as e:
        print(e)
