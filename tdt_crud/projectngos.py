from app import app
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@app.route('/projectngo', methods=['POST'])
@require_appkey
def projectngo_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _ngoid = content['NgoId']

        sql = "CALL usp_AddNGOToProject(%s, %s)"
        data = (_projectid, _ngoid,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/projectngo/<int:id>', methods=['DELETE'])
@require_appkey
def delete_projectngo(id):
    try:
        sql = "CALL usp_RemoveNGOFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

        from app import app
from flask import flash, request
import sqlhelper

@app.route('/projectngo/<int:projectid>', methods=['GET'])
@require_appkey
def projectngo(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetNGOsForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)
