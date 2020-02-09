from app import app
from flask import flash, request
import sqlhelper

@app.route('/projectcategory', methods=['POST'])
def projectcategory_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _categoryid = content['CategoryId']

        sql = "CALL usp_AddCategoryToProject(%s, %s)"
        data = (_projectid, _categoryid,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/projectcategory/<int:id>', methods=['DELETE'])
def delete_projectcategory(id):
    try:
        sql = "CALL usp_RemoveCategoryFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/projectcategory/<int:projectid>', methods=['GET'])
def projectcategory(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetCategoriesForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)